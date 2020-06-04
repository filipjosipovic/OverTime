const express = require("express");
const router = express.Router();
const bcrypt = require("bcryptjs");
const passport = require('passport');

// User model
const User = require("../models/User");

// Login Page
router.get("/login", (req, res) => res.render("login"));

// Register Page
router.get("/Register", (req, res) => res.render("register"));

// Register Handle
router.post("/register", (req, res) => {
  const { name, username, password, password2 } = req.body;
  let errors = [];

  // TODO: Add some REGEX razzle dazzle
  // Check required fields
  if (!name || !username || !password || !password2) {
    errors.push({ msg: "Please fill in all fields" });
  }

  // Password Match check
  if (password !== password2) {
    errors.push({ msg: "Passwords do not match" });
  }

  // Check pass length
  if (password.length < 6) {
    errors.push({ msg: "Password should be at least 6 characters" });
  }

  if (errors.length > 0) {
    res.render("register", {
      errors,
      name,
      username,
      password,
      password2,
    });
  } else {
    // Validation Passed
    User.findOne({ username: username }).then((user) => {
      if (user) {
        // User exists
        errors.push({ msg: "Username is already registered " });
        res.render("register", {
          errors,
          name,
          username,
          password,
          password2,
        });
      } else {
        const newUser = new User({
          name,
          username,
          password,
        });

        // Hash Password
        bcrypt.genSalt(10, (err, salt) =>
          bcrypt.hash(newUser.password, salt, (err, hash) => {
              if (err) throw err;
              // Set password to hashed
              newUser.password = hash;
              // Save User
                newUser.save()
                .then(user => {
                    // req.flash('success_msg','You are now registered and can log in');
                    res.redirect('/users/login');
                })
                .catch(err => console.log(err));
              
          })
        );
      }
    });
  }
});

// Login Handle
router.post('/login',(req,res,next)=>{
  passport.authenticate('local',{
    successRedirect:'/dashboard',
    failureRedirect:'/users/login',
    // failureFlash: true
  })(req,res,next);
});

// Logout Handle
router.get('/logout',(req,res)=>{
  req.logout();
  // req.flash('success_msg','You are logged out');
  res.redirect('/users/login');
});


module.exports = router;

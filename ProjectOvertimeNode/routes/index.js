const express = require("express");
const router = express.Router();
const User = require("../models/User");
const passport = require("passport");

// Welcome Page
router.get("/", (req, res) => res.render("login"));

// Login Handle
router.post("/", (req, res, next) => {
  passport.authenticate("local", {
    successRedirect: "/main",
    failureRedirect: "/fail",
  })(req, res, next);
});

// Main
router.get("/main", (req, res) => {
  const firstname = req.user.name.split(" ")[0];
  const lastname = req.user.name.split(" ")[1];
  
  res.render("main", {
    firstname: firstname,
    lastname: lastname,
  });

});

router.post("/main", (req, res, next) => {
  const { starttime, endtime, room } = req.body;
  console.log(starttime);
  console.log(endtime);
  console.log(room);
  req.user.startTime = starttime;
  req.user.endTime = endtime;
  req.user.Room = room;
  req.user.save(function (err, doc) {
    if (err) return console.error(err);
    console.log("Document inserted succussfully!");
  });
});

module.exports = router;

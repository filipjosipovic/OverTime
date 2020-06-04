const express = require("express");
const router = express.Router();
const User = require("../models/User");
const passport = require("passport");

router.get("/key0x0ff2b", function (req, res) {
  User.find({}, function (err, users) {
    let userMap = [];

    users.forEach(function (user) {
      if (user.startTime !== "00:00") {
        userMap.push(user);
      }
    });

    res.render("overtime", { userMap });
  });
});

module.exports = router;

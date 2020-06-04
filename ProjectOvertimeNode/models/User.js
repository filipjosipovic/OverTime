const mongoose = require('mongoose');

const UserSchema = new mongoose.Schema({
    name:{
        type:String,
        required: true
    },
    username:{
        type:String,
        required: true
    },
    password:{
        type:String,
        required: true
    },
    startTime:{
        type:String,
        default: '00:00'
    },
    endTime:{
        type:String,
        default: '00:00'
    },
    Room:{
        type:String,
        default: ""
    },
    date:{
        type:Date,
        default: Date.now
    }

});

const User = mongoose.model('User',UserSchema);
module.exports = User;
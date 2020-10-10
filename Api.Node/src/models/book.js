'use strict'

const mongoose = require('mongoose');
const Schema = mongoose.Schema;

const schema = new Schema({
    Name: {
        type: String,
        required: true,
    },
    Category: {
        type: String,
        required: true
    },
    Value: {
        type: Number,
        required: true,
    },
    Active: {
        type: Boolean,
        required: true
    },
    Description: {
        type: String,
        required: true,
    }
});

module.exports = mongoose.model('Book', schema);
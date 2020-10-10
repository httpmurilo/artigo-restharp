
'use strict';

const mongoose = require('mongoose');
const Book = mongoose.model('Book');


exports.get = async () => {
    const res = await Book.find({
        Active: true
    });
    return res;
}

exports.create = async (data) => {
    var book = new Book(data);
    await book.save();
}

exports.update = async (id,data) => {
   await  Book
        .findByIdAndUpdate(id,{
            $set:{
            Name: data.Name,
            Category: data.Category,
            Value: data.Value,
            Active: data.Active,
            Description : data.Description
        }
    });
}

exports.delete = async (id) =>{
    await Book
        .findOneAndRemove(id);
}
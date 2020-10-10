'use strict'

const express = require('express');
const router = express.Router();
const controller = require('../controllers/Book-Controller');



router.post('/',controller.post);
router.delete('/:id',controller.delete);
router.get('/',controller.get);
router.put('/:id',controller.put);

module.exports = router;
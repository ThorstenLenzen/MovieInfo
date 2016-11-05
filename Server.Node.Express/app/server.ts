import * as express from 'express';
import * as mongoose from 'mongoose';
import { WebApi } from './webapi';

mongoose.connect('mongodb://localhost/movies');

let port = 5001; //or from a configuration file
let api = new WebApi(express(), port);
api.run();
 
console.info(`listening on ${port}`);
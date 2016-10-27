import { RequestHandler, NextFunction, Request, Response } from 'express';

export class RequestLogger {

    public handler: RequestHandler;

    constructor() {
        this.handler = this.log;
    }

    public log(request: Request, response: Response, next: NextFunction): void {
        console.info(`${(new Date()).toUTCString()}|${request.method}|${request.url}|${request.ip}`);
        next();
    }
}
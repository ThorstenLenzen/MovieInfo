import { Router, Request, Response } from 'express';

export class TestRouter {

    public router: Router;

    constructor() {
        this.router = Router();

        var a;

        this.router.get('/', this.getTestData);
    }

    public getTestData(request: Request, response: Response): void {
        let testData = {
            firstName: 'The',
            lastName: 'Burge'
        };

        response.json(testData);
    }
}
import {
    Router,
    Request,
    Response
} from 'express';

import {
    Document,
    Model
} from 'mongoose';

export class BaseMongooseRouter<TModel extends Document>  {

    private _router: Router;

    constructor(private model: Model<TModel>) {
        this._router = Router();

        this._router.get('/', this.getDocument);
        this._router.get('/:id', this.getDocumentById);
        this._router.post('/', this.createDocument);
        this._router.put('/:id', this.updateDocument);
        this._router.patch('/:id', this.updateDocument);
        this._router.delete('/:id', this.deleteDocument);
    }

    public get Router(): Router {
        return this._router;
    }

    protected get Model(): Model<TModel> {
        return this.model;
    }

    // GET /movie
    private getDocument = (request: Request, response: Response): void => {
        this.model.find({ }, (error, document) => {
            if (error) {
                response.status(500).json(error);
            } else {
                response.status(200).json(document);
            }
        });
    }

    // GET /movie/5804c380c28a3bc7eaeab26a
    private getDocumentById = (request: Request, response: Response): void => {
        this.model.findById(request.params['id'], (error, document) => {
            if (error) {
                response.status(500).json(error);
            } else {
                if (document === null) {
                    response.status(404);
                } else {
                    response.status(200).json(document);
                }
            }
        });
    }

    // POST /movie
    private createDocument = (request: Request, response: Response): void => {
        this.model.create([request.body], (error, document) => {
            if (error) {
                response.status(500).json(error);
            } else {
                response.status(200).json(document);
            }
        });
    }

    // PUT /movie/5804c380c28a3bc7eaeab26a
    // PATCH /movie/5804c380c28a3bc7eaeab26a
    private updateDocument = (request: Request, response: Response): void => {
        this.model.findOneAndUpdate({_id: request.params['id']}, request.body, (error, document) => {
            if (error) {
                response.status(500).json(error);
            } else {
                response.status(200).json(document);
            }
        });
    }

    // DELETE /movie/5804c380c28a3bc7eaeab26a
    private deleteDocument = (request: Request, response: Response): void =>  {
        this.model.remove({_id: request.params['id']}, error => {
            if (error) {
                response.status(500).json(error);
            } else {
                response.status(200);
            }
        });
    }
}
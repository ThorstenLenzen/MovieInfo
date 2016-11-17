import { Application } from 'express';
import * as bodyParser from 'body-parser';
import { movieRouter} from './routes';
import { RequestLogger } from './middleware';

export class WebApi {
    /**
     * @param app - express application
     * @param port - port to listen on
     */
    constructor(private app: Application, private port: number) {
        this.configureMiddleware(app);
        this.configureRoutes(app);
    }

    /**
     * @param app - express application
     */
    private configureMiddleware(app: Application) {
        app.use(new RequestLogger().handler);
        app.use(bodyParser.json());
    }

    private configureRoutes(app: Application) {
        app.use('/movie', movieRouter);
        // mount more routers heretask
    }

    public run() {
        this.app.listen(this.port);
    }
}
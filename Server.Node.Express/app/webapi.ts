import { Application } from 'express';
import { TestRouter } from './routes/testRouter';
import { MovieRouter } from './routes/movieRouter';
import { RequestLogger } from './middleware/requestLogger';

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
    }

    private configureRoutes(app: Application) {
        app.use('/test', new TestRouter().router);
        app.use('/movie', new MovieRouter().router);
        // mount more routers here
        // e.g. app.use("/organisation", organisationRouter);
    }

    public run() {
        this.app.listen(this.port);
    }
}
import { MovieInfoGuiPage } from './app.po';

describe('movie-info-gui App', () => {
  let page: MovieInfoGuiPage;

  beforeEach(() => {
    page = new MovieInfoGuiPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});

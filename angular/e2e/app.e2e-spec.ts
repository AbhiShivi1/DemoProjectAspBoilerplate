import { MyDemoProjectTemplatePage } from './app.po';

describe('MyDemoProject App', function() {
  let page: MyDemoProjectTemplatePage;

  beforeEach(() => {
    page = new MyDemoProjectTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});

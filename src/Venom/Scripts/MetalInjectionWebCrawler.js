(function metalInjectionCrawler() {
  (function parser() {
    let reviews = parse("category-reviews");
    let videos = parse("type-video");
    let tours = parse("category-tour-dates");

    print([reviews, videos, tours]);
  })();

  function parse(category) {
    const articles = document.querySelectorAll(`article.${category}`);

    return toArray(articles).map(toObject);
  }

  function toArray(items) {
    return Array.prototype.slice.call(items);
  }

  function toObject(article) {
    const anchor = article.querySelector("a");
    const title = article.querySelector(".content .title");
    const meta = article.querySelector(".content .meta > a");
    const category = article.querySelector(".content .category > a");

    return {
      url: anchor.href,
      title: title.innerText,
      author: {
        name: meta.innerHTML,
        url: meta.href,
        date: meta.nextSibling.textContent.replace("|", "").trim()
      },
      category: category.innerHTML
    };
  }

  function print(articles) {
    articles.filter(a => a.length > 0).forEach(console.log);
  }
})();

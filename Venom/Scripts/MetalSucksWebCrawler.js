(function metalSucksCrawler() {
  (function parser() {
    let reviews = parse("Review");
    let videos = parse("VideoObject");
    let tours = parse("NewsArticle");

    print([reviews, videos, tours]);
  })();

  function parse(category) {
    const articles = document.querySelectorAll(
      `article[itemtype="http://schema.org/${category}"]`
    );

    return toArray(articles).map(toObject);
  }

  function toArray(items) {
    return Array.prototype.slice.call(items);
  }

  function toObject(article) {
    const anchor = article.querySelector("span[itemprop='url'] a.full-cover");
    const title = article.querySelector(".post-title a");
    const meta = article.querySelector(".content-block .author > a");
    const category = article.querySelector(
      "span[itemprop='url'] a.category-tag"
    );

    return {
      url: anchor.href,
      title: title.innerText,
      author: {
        name: meta.innerHTML,
        url: meta.href,
        date: meta.parentNode.parentNode
          .querySelector("time")
          .getAttribute("datetime")
      },
      category: category.innerHTML
    };
  }

  function print(articles) {
    articles.filter(a => a.length > 0).forEach(console.log);
  }
})();

function getArticleGenerator(articles)
{
    let content = document.querySelector('#content');

    return function showNext()
    {
        if (articles.length != 0)
        {
            let articleEl = document.createElement('article');
            articleEl.textContent = articles.shift();
            content.appendChild(articleEl);
        }
    }
}

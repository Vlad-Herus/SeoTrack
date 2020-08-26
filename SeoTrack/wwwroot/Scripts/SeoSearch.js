

function onSearchClick()
{
    let queryText = document.getElementById("queryInput").value;
    let resultContainer = document.getElementById("resultContainer");

    $.ajax(
        {
            type: "GET",
            url: "Home/GetLinkIds",
            dataType: "json",
            data: { query: queryText },
            success: (res) => {
                res.forEach(item => {
                    let line = item.engineName + " " + item.entries;
                    let content = document.createTextNode(line);
                    let lineBreakElement = document.createElement("br");
                    resultContainer.appendChild(content);
                    resultContainer.appendChild(lineBreakElement);
                });
            },
            error: (xhr, ajaxOptions, thrownError) => {
                let lineBreakElement = document.createElement("br");
                let content = document.createTextNode("Failed to fetch seo search result from the server.");
                resultContainer.appendChild(content);
                resultContainer.appendChild(lineBreakElement);
            }
        });
}
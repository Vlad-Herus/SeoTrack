

function onSearchClick()
{
    $.get("Home/GetValues", { request: 'ferty' },
        (res) =>
        {
            let container = $('#result');
            res.forEach(item =>
            {
                let line = item.engineName + ' ' + item.entries;
                container.append(line);
                container.append('<br/>');
            });
        }, "json");
}
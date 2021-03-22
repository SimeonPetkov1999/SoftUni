function solve(obj)
{
    let methods = ['GET', 'POST', 'DELETE', 'CONNECT'];
    let validVerisons = ['HTTP/0.9', 'HTTP/1.0', 'HTTP/1.1', 'HTTP/2.0'];

    if (!methods.includes(obj.method)) 
    {
        throw new Error(`Invalid request header: Invalid Method`);
    }
    if (!/^[\w*\.]+$/gm.test(obj.uri)) 
    {
        throw new Error(`Invalid request header: Invalid URI`)
    }
    if (!validVerisons.includes(obj.version))
    {
        throw new Error("Invalid request header: Invalid Version");
    }
    if (!(/^[^<>\\&'"]*$/.test(obj.message) || obj.message == ''))
    {
        throw new Error("Invalid request header: Invalid Message");
    }
    return obj;
}

console.log(solve({
    method: 'GET',
    uri: 'svn.public.catalog',
    version: 'HTTP/1.1',
    message: ''
}
))
function encodeAndDecodeMessages() 
{
    let decodeButton = document.querySelectorAll('button')[0];
    let encodeButton = document.querySelectorAll('button')[1];
    let decodeTextArea = decodeButton.parentNode.children[1];
    let encodeTextArea = encodeButton.parentNode.children[1];

    decodeButton.addEventListener('click', decode);
    encodeButton.addEventListener('click', encode);


    function decode(e)
    {
        let textToDecode = decodeTextArea.value;
        let decoded = '';

        Array.from(textToDecode).forEach(letter => 
        {
            decoded += nextChar(letter);
        });

        encodeTextArea.value = decoded;
        decodeTextArea.value=''
    }

    function encode(e)
    {
        let textToEncode = encodeTextArea.value;
        let encoded = '';

        Array.from(textToEncode).forEach(letter =>
        {
            encoded+=previousChar(letter);
        })

        encodeTextArea.value = encoded
       
    }

    function nextChar(c) 
    {
        return String.fromCharCode(c.charCodeAt(0) + 1);
    }

    function previousChar(c) 
    {
        return String.fromCharCode(c.charCodeAt(0) - 1);
    }
}
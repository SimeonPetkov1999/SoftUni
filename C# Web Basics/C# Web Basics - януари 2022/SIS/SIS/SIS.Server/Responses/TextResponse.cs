﻿using SIS.Server.HTTP;

namespace SIS.Server.Responses
{
    public class TextResponse : ContentResponse
    {
        public TextResponse(string text,Action<Request,Response> preRenderedAction = null) 
            : base(text, ContentType.PlainText,preRenderedAction)
        {
        }
    }
}

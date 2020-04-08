using System;
using System.Collections.Generic;
using System.Text;

namespace Client
{
    class BaseResponse
    {
        public BaseResponse()
        {
            m_ResponseStatus = 0;
            m_ResponseText = "";
        }
        public int ResponseStatus
        {
            get { return m_ResponseStatus; }
            set { m_ResponseStatus = value; }
        }

        public string ResponseText
        {
            get { return m_ResponseText; }
            set { m_ResponseText = value; }
        }

        public override string ToString()
        {
            if (m_ResponseStatus == 0 && m_ResponseText.Length == 0)
            {
                return "";
            }
            else if(m_ResponseStatus != 0 && m_ResponseText.Length == 0)
            {
                return $"Response status: {m_ResponseStatus}";
            }
            else if(m_ResponseStatus == 0 && m_ResponseText.Length != 0)
            {
                return $"Response Message: {m_ResponseText}";
            }
            return $"Response status: {m_ResponseStatus} \nResponse Message: {m_ResponseText}";
        }

        private int m_ResponseStatus;
        private string m_ResponseText;
    }
}

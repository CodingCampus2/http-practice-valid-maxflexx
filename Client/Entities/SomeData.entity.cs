using System;
using System.Collections.Generic;
using System.Text;

namespace Client
{
    class SomeData
    {
        public SomeData()
        {
            m_DataId = "";
            m_Weight = 0;
        }
        public SomeData(string dataId, int weight)
        {
            m_DataId = dataId;
            m_Weight = weight;
        }
        public string dataId
        {
            get { return m_DataId; }
            set { m_DataId = value; }
        }

        public int weight
        {
            get { return m_Weight; }
            set { m_Weight = value; }
        }

        public override string ToString()
        {
            if (m_DataId.Length == 0)
            {
                return "";
            }
            return $"Id: {m_DataId}, Weight: {m_Weight}";
        }

        private string m_DataId;
        private int m_Weight;
    }
}

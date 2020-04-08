using System;
using System.Collections.Generic;
using System.Text;

namespace Client
{
    class SingleSomeData : BaseResponse
    {
        public SingleSomeData() : base()
        {
            m_Data = new SomeData();
        }

        public SomeData Data
        {
            get { return m_Data; }
            set { m_Data = value; }
        }

        public override string ToString()
        {
            return $"{base.ToString()}\n{m_Data.ToString()}";
        }

        private SomeData m_Data;
    }
}

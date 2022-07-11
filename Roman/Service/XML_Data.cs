using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roman.Service
{
    class XML_Data
    {
        private List<string> _tableName;
        private List<List<string>> _inputParams;
        private List<List<string>> _inputValues;

        public List<string> TableName { get { return _tableName; } }
        public List<List<string>> InputParams { get { return _inputParams; } }
        public List<List<string>> InputValues { get { return _inputValues; } }

        public XML_Data(List<string> TableName, List<List<string>> InputParams, List<List<string>> InputValues)
        {
            _tableName = TableName;
            _inputParams = InputParams;
            _inputValues = InputValues;
        }
    }
}

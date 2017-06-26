using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finview.Entities.Unity
{
    public class FinviewContainer
    {
        private static object lobject = new object();

        private static FinviewContainer _local;

        private IUnityContainer _container;

        private FinviewContainer()
        {
            _container = new UnityContainer();
        }
        public static IUnityContainer Instance
        {
            get
            {
                if(_local == null)
                {
                    lock (lobject)
                    {
                        if (_local == null)
                        {
                            _local = new FinviewContainer();
                        }   
                    }
                }
                return _local._container;
            }
        }
    }
}

using ClickHouse.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    /*===================================================
	 * 类名称: ClickHouseQueryLogger
	 * 类描述:
	 * 创建人: wangchong
	 * 创建时间: 2020/11/20 18:07:01
	 * 修改人:
	 * 修改时间:
	 * 版本： @version 1.0
	 =====================================================*/
    public class ClickHouseQueryLogger : IClickHouseQueryLogger
    {
        public void AfterQuery(string queryText)
        {
            
        }

        public void BeforeQuery()
        {
            
        }
    }
}

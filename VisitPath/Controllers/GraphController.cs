using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TripWay.Library;

namespace VisitPath.Controllers
{
    [Route("api/[controller]")]
    public class GraphController : Controller
    {

        [HttpPost("[action]")]
        public object MinimumSpanningTree([FromBody] GraphData data)
        {
           IGraphCommand mstGraphCommand = new MSTGraphCommand(data);
            return mstGraphCommand.Execute();
        }

        public class GraphData
        {
            public string InitialVertex { get; set; }
            public string[] Vertices { get; set; }
            public Edge[] Edges { get; set; }
        }

        public class Edge
        {
            public string FromVertex { get; set; }
            public string ToVertex {get; set;}
            public int Distance { get; set; }
        }
    }
}

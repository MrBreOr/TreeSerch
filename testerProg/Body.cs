namespace testerProg
{
    internal class Body
    {
        public Dictionary<string, int> costs = new() { { End, int.MaxValue } };
        public Dictionary<string, string> perents = new();

        public Dictionary<string, Dictionary<string, int>> graph = new() { { Start, new() } };


        public const string Start = "start";
        public const string End = "end";

        public Body(params string[] list)
        {
            foreach (string l in list)
            {
                graph[l] = new();
                costs[l] = int.MaxValue;
            }
        }

        public void Add(params (string,string,int)[] param)
        {
            foreach (var p in param)
            {
                graph[p.Item1][p.Item2] = p.Item3;
                perents[p.Item2] = p.Item1;
            }

            foreach (var name in graph[Start].Keys)
            {
                costs[name] = graph[Start][name];
            }
        }



        public void Processed(string startName = Start)
        {
            List<string> allOff = new() { Start, End };

            while (allOff.Count != costs.Count)  
            {
                string name = FindMinCach(allOff);
                Dictionary<string, int> node = graph[name];
                foreach (var n in node.Keys)
                {
                    int cost = costs[name];
                    int new_costs = cost + node[n];

                    if (costs[n] > new_costs)
                    {
                        costs[n] = new_costs;
                        perents[n] = name;
                    }
                }
                allOff.Add(name);
            }
        }

        private string FindMinCach(List<string> names)
        {
            int minCach = int.MaxValue;
            string nameMin = "";
            foreach (var name in costs.Keys)
            {
                if (Serch(names, name)) continue;

                if(minCach > costs[name])
                {
                    minCach = costs[name];
                    nameMin = name;
                }
            }
            return nameMin;
        }

        private bool Serch(List<string> allOff, string name)
        {
            foreach(var a in allOff)
            {
                if (name == a) return true;
            }
            return false;
        }

        public int MinPath()
        {
            return costs[End];
        }
    }
}

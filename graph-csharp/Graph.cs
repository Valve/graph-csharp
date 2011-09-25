using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace graph_csharp {
    public class Graph {

        private int _v;
        private int _e;
        private HashSet<int>[] _adj;

        public Graph(int v) {
            Initialize(v);
        }

        private void Initialize(int v) {
            _v = v;
            _e = 0;
            _adj = new HashSet<int>[v];
            v.Times(i => _adj[i] = new HashSet<int>());
        }

        public Graph(Stream stream) {
            var streamReader = new StreamReader(stream);
            string line = streamReader.ReadLine();
            Initialize(int.Parse(line));
            line = streamReader.ReadLine();
            int e = int.Parse(line);
            e.Times(() => {
                var numbers = streamReader.ReadLine().Split(' ');
                int v = int.Parse(numbers[0]);
                int w = int.Parse(numbers[1]);
                AddEdge(v, w);
            });
        }

        public int V { get { return _v; } }

        public int E { get { return _e; } }

        public void AddEdge(int v, int w) {
            _adj[v].Add(w);
            _adj[w].Add(v);
            _e++;
        }

        public IEnumerable<int> Adjacent(int v) {
            return _adj[v];
        }

        public static int Degree(Graph g, int v) {
            return g.Adjacent(v).Count();
        }
        public static int MaxDegree(Graph g) {
            int max = 0;
            g.V.Times(v => {
                if (Degree(g, v) > max) {
                    max = Degree(g, v);
                }
            });
            return max;
        }

        public static int AverageDegree(Graph g) {
            return 2 * g.E / g.V;
        }

        public static int NumberOfSelfLoops(Graph g) {
            int count = 0;
            g.V.Times(v => {
                foreach (int w in g.Adjacent(v)) {
                    if (v == w) count++;
                }
            });
            return count / 2;
        }

        public override string ToString() {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat("{0} vertices, {1} edges\n", V, E);
            V.Times(v => {
                stringBuilder.AppendFormat("{0}:", v);
                foreach (int w in Adjacent(v)) {
                    stringBuilder.AppendFormat("{0} ", w);
                    stringBuilder.Append(Environment.NewLine);
                }
            });
            return stringBuilder.ToString();
        }
    }
}

﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Traversal
{
    class Program
    {
        static Dictionary<string, string[]> graphic = new Dictionary<string, string[]>
        {
            { "A", new []{ "B", "C"} },
            { "B", new []{ "A", "C", "D"} },
            { "C", new []{ "A", "B", "D", "E"} },
            { "D", new []{ "B", "C", "E", "F"} },
            { "E", new []{ "C", "D"} },
            { "F", new []{ "D"} },
        };

        // 纪录每个节点的邻近父节点
        static Dictionary<string, string> parent = new Dictionary<string, string>();

        static void Main(string[] args)
        {
            Console.WriteLine("Please enter number for graph travelsal:");
            Console.WriteLine("1.Brand First Search   2.Deep First Search");
            Console.Write("Option: ");
            var option = "";
            option = Console.ReadLine();
            Console.Write("Start Point(A-F): ");
            var start = "";
            start = Console.ReadLine();
            parent[start] = "NONE";
            switch (option)
            {
                case "1":
                    BFS(start);
                    break;
                case "2":
                    DFS(start);
                    break;
                default:
                    break;
            }

            // 输出父节点
            Console.WriteLine("Point -> Parent Point");
            foreach (var item in parent)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }

            // 寻找最短路径
            Console.Write("End Point(A-F): ");
            var end = "";
            end = Console.ReadLine();
            while(end != "NONE")
            {
                Console.WriteLine(end);
                end = parent[end];
            }
        }

        static void BFS(string point)
        {
            // 初始化将起始点放入队列中
            var queue = new Queue();
            queue.Enqueue(point);
            var seen = new HashSet<string>();
            seen.Add(point);
            while (queue.Count > 0)
            {
                var vertex = queue.Dequeue().ToString();
                var nodes = graphic[vertex];
                foreach (var node in nodes)
                {
                    // 如果尚未存在该点则加入该点
                    if(!seen.Contains(node))
                    {
                        queue.Enqueue(node);
                        seen.Add(node);
                        // 纪录不存在点的父节点
                        parent[node] = vertex;
                    }                    
                }
                Console.WriteLine(vertex);
            }
        }

        static void DFS(string point)
        {
            // 初始化将起始点放入队列中
            var stack = new Stack();
            stack.Push(point);
            var seen = new HashSet<string>();
            seen.Add(point);
            while (stack.Count > 0)
            {
                var vertex = stack.Pop().ToString();
                var nodes = graphic[vertex];
                foreach (var node in nodes)
                {
                    // 如果尚未存在该点则加入该点
                    if (!seen.Contains(node))
                    {
                        stack.Push(node);
                        seen.Add(node);
                        // 纪录不存在点的父节点
                        parent[node] = vertex;
                    }
                }
                Console.WriteLine(vertex);
            }
        }
    }
}

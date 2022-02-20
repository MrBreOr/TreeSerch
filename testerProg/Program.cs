Body body = new Body("a", "b", "c", "d");
body.Add((Body.Start, "a", 2),
         (Body.Start, "b", 2),
         ("b", "a", 2),
         ("a", Body.End, 2),
         ("a", "c", 2),
         ("c", "b", -1),
         ("c", Body.End, 2));

body.Processed();

Console.WriteLine(body.MinPath());

Console.ReadKey();


//List<Body> testTree = new List<Body>(6);
//testTree.Add(new Body("start", new Dictionary<string, int> { { "A", 5 }, { "B", 2 } }));
//testTree.Add(new Body("A", new Dictionary<string, int> { { "",  }, { "",  } }));
//testTree.Add(new Body("B", new Dictionary<string, int> { { "",  }, { "",  } }));
//testTree.Add(new Body("C", new Dictionary<string, int> { { "",  }, { "",  } }));
//testTree.Add(new Body("D", new Dictionary<string, int> { { "",  }, { "",  } }));
//testTree.Add(new Body("end", new Dictionary<string, int> { { "",  }, { "",  } }));
namespace Assignment_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ════════════════════════════════════════════════════════════
            // Q1 – Products in "Seafood" category
            // ════════════════════════════════════════════════════════════

            Console.WriteLine("=== Q1: Seafood Products ===");

            var seafood = ProductList
                .Where(p => p.Category == "Seafood")
                .Select(p => new { p.ProductName, p.UnitPrice });

            foreach (var p in seafood)
                Console.WriteLine($"  {p.ProductName,-30} ${p.UnitPrice:F2}");
            // ════════════════════════════════════════════════════════════
            // Q2 – Product names only
            // ════════════════════════════════════════════════════════════

            Console.WriteLine("\n=== Q2: Product Names ===");

            var names = ProductList.Select(p => p.ProductName);
            foreach (var n in names) Console.WriteLine($"  {n}");
            // ════════════════════════════════════════════════════════════
            // Q3 – Sort by UnitPrice ascending
            // ════════════════════════════════════════════════════════════

            Console.WriteLine("\n=== Q3: Sorted by Price (asc) ===");

            var byPrice = ProductList
                .OrderBy(p => p.UnitPrice)
                .Select(p => new { p.ProductName, p.UnitPrice });

            foreach (var p in byPrice)
                Console.WriteLine($"  {p.ProductName,-30} ${p.UnitPrice:F2}");
            // ════════════════════════════════════════════════════════════
            // Q4 – UnitPrice between 10 and 30
            // ════════════════════════════════════════════════════════════

            Console.WriteLine("\n=== Q4: Price $10–$30 ===");

            var midRange = ProductList.Where(p => p.UnitPrice >= 10 && p.UnitPrice <= 30);
            foreach (var p in midRange)
                Console.WriteLine($"  {p.ProductName,-30} ${p.UnitPrice:F2}");
            // ════════════════════════════════════════════════════════════
            // Q5 – In-stock Condiments
            // ════════════════════════════════════════════════════════════

            Console.WriteLine("\n=== Q5: In-Stock Condiments ===");

            var condiments = ProductList
                .Where(p => p.UnitsInStock > 0 && p.Category == "Condiments");

            foreach (var p in condiments)
                Console.WriteLine($"  {p.ProductName}");
            // ════════════════════════════════════════════════════════════
            // Q6 – Anonymous type with StockStatus
            // ════════════════════════════════════════════════════════════

            Console.WriteLine("\n=== Q6: Anonymous Type with StockStatus ===");

            var stockInfo = ProductList.Select(p => new
            {
                Name = p.ProductName,
                Price = p.UnitPrice,
                StockStatus = p.UnitsInStock > 0 ? "Available" : "Out of Stock"
            });

            foreach (var item in stockInfo)
                Console.WriteLine($"  {item.Name,-30} ${item.Price:F2}  [{item.StockStatus}]");
            // ════════════════════════════════════════════════════════════
            // Q7 – Product name with 1-based position
            // ════════════════════════════════════════════════════════════

            Console.WriteLine("\n=== Q7: Position + Name ===");

            var numbered = ProductList.Select((p, i) => $"{i + 1}. {p.ProductName}");
            Console.WriteLine(string.Join(", ", numbered));
            // ════════════════════════════════════════════════════════════
            // Q8 – Sort by Category asc, then UnitPrice desc
            // ════════════════════════════════════════════════════════════

            Console.WriteLine("\n\n=== Q8: Category ↑, Price ↓ ===");

            var sorted = ProductList
                .OrderBy(p => p.Category)
                .ThenByDescending(p => p.UnitPrice);

            foreach (var p in sorted)
                Console.WriteLine($"  [{p.Category,-15}]  {p.ProductName,-30}  ${p.UnitPrice:F2}");
            // ════════════════════════════════════════════════════════════
            // Q9 – Beverages sorted by stock desc
            // ════════════════════════════════════════════════════════════

            Console.WriteLine("\n=== Q9: Beverages by Stock ↓ ===");

            var beverages = ProductList
                .Where(p => p.Category == "Beverages")
                .OrderByDescending(p => p.UnitsInStock);

            foreach (var p in beverages)
                Console.WriteLine($"  {p.ProductName,-30}  stock: {p.UnitsInStock}");

            // ════════════════════════════════════════════════════════════
            // Q10 – Orders from 1997+ (QUERY SYNTAX with compound from)
            // ════════════════════════════════════════════════════════════

            Console.WriteLine("\n=== Q10: Orders ≥ 1997 (query syntax) ===");

            
            var orders97 =
                from c in CustomerList
                from o in c.Orders
                where o.OrderDate.Year >= 1997
                select new { c.CustomerID, o.OrderDate };

            foreach (var o in orders97)
                Console.WriteLine($"  {o.CustomerID,-12}  {o.OrderDate:yyyy-MM-dd}");
            // ════════════════════════════════════════════════════════════
            // Q11 – Position number alongside ProductName
            // ════════════════════════════════════════════════════════════

            Console.WriteLine("\n=== Q11: Index + ProductName ===");

            var withIndex = ProductList
                .Select((p, i) => new { Position = i + 1, p.ProductName });

            foreach (var x in withIndex)
                Console.WriteLine($"  {x.Position,3}. {x.ProductName}");
            // ════════════════════════════════════════════════════════════
            // Q12 – Sort by word-length then case-insensitive alphabetical
            // ════════════════════════════════════════════════════════════

            Console.WriteLine("\n=== Q12: Sort by Length then Alphabetical ===");

            string[] arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

            var sortedArr = arr
                .OrderBy(w => w.Length)
                .ThenBy(w => w, StringComparer.OrdinalIgnoreCase);

            Console.WriteLine(string.Join(", ", sortedArr));
            // ════════════════════════════════════════════════════════════
            // Q13 – Digits whose second letter is 'i', reversed
            // ════════════════════════════════════════════════════════════

            Console.WriteLine("\n=== Q13: Words with 2nd letter 'i', reversed ===");

            string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

         
            var filtered = digits
                .Where(d => d.Length >= 2 && d[1] == 'i')
                .Reverse();

            Console.WriteLine(string.Join(", ", filtered));


        }
    }
}

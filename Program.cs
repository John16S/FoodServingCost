using FoodServingCost;
using System.Text;

//установка кодировки консоли в UTF-8
Console.OutputEncoding = Encoding.UTF8;
Console.InputEncoding = Encoding.UTF8;

/*------------------------------------------------Ввод Продуктов---------------------------------------------------------*/
//Лист для хранение продуктов
List<Product> products = new List<Product>();
Console.WriteLine("Введите информацию о продуктах (название, объем, стоимость) или 'finish' для завершения ввода:");
Console.WriteLine("****************************************************************************");
//Пока не введено "finish", просим пользователя вводит данные продуков
while (true)
{
    Console.Write("Продукт: ");
    string input = Console.ReadLine();

    if (input.ToLower() == "finish") break;

    string[] productInfo = input.Split(',');
    if (productInfo.Length != 3)
    {
        Console.WriteLine("Неправильный формат. Введите продукт в формате 'название, объем, стоимость'.");
        continue;
    }

    // Записываем название продукта в productName
    string productName = productInfo[0].Trim();

    // Преобразовываем значения из строк productInfo[1] и productInfo[2] в числа типа double
    if (!double.TryParse(productInfo[1], out double volume) || !double.TryParse(productInfo[2], out double price))
    {
        Console.WriteLine("Неверные данные для объема или стоимости продукта.");
        continue;
    }

    // Создаём новый объект Product и сразу записываем данные продукта, затем этот объект добавляем в список products
    products.Add(new Product { Name = productName, Volume = volume, Price = price });
}

/*------------------------------------------------Ввод рецепта--------------------------------------------------------------------------*/
Console.WriteLine("****************************************************************************");
//Вводим данные рецепта
Console.Write("Введите название Рецепта: ");
string recipeName = Console.ReadLine();

//Лист для объёма ингридиентов
List<double> required_volume = new List<double>();
Console.WriteLine("Введите объём ингридиентов: ");
//Вводим необх. объема для каждого продукта
foreach (var product in products)
{
    Console.Write($"\t{product.Name}: ");
    //Используем цикл чтоб при неправильном вводе прога не закрывалась
    while (true)
    {
        if (!int.TryParse(Console.ReadLine(), out int volume))
        {
            Console.WriteLine("\tНеправильное объём(количество). Введите целое число");
        }
        else if (volume == 0 || volume > product.Volume)
        {
            Console.WriteLine("\tНеобходимый объём не может быть равен 0 или больше самого объёма");
        }
        else
        {
            required_volume.Add(volume);
            break; // Выход из цикла, так как данные введены правильно
        }
    }
}

//Вводим количество порций
Console.Write("Введите количество порций блюда: ");
if (!int.TryParse(Console.ReadLine(), out int servings))
{
    Console.WriteLine("Неправильное количество порций. Введите целое число");
    return;
}

//Создаём объект и заполняем его данными
Recipe recipe = new Recipe()
{
    Name = recipeName,
    Products = products,
    RequiredVolume = required_volume,
    Servings = servings
};

Console.WriteLine("****************************************************************************");

/*---------------------------------------------------Вывод резултата-----------------------------------------------------------------------*/

//У 'recipe' вызываем метод calculateCostPerServing и записываем его результат в totalCost
double totalCost =  recipe.calculateCostPerServing();
//Выводим стоимость одной порции блюда
Console.WriteLine($"Стоимость одной порции блюда {recipe.Name}: {totalCost} рублей");
Console.WriteLine("****************************************************************************");

Console.ReadLine();
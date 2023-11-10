using FoodServingCost;
using System.Text;

//установка кодировки консоли в UTF-8
Console.OutputEncoding = Encoding.UTF8;
Console.InputEncoding = Encoding.UTF8;

/*------------------------------------------------Ввод Продуктов---------------------------------------------------------*/
//Лист для хранение продуктов
List<Product> products = new List<Product>();
Console.WriteLine("Введите информацию о продуктах (название, объем, стоимость) или 'f (finish)' для завершения ввода:");
Console.WriteLine("****************************************************************************");
//Пока не введено "finish", просим пользователя вводит данные продуков
while (true)
{
    Console.Write("Продукт: ");
    string input = Console.ReadLine();

    //Проверка, если введен "finish", то выходим из цикла
    if (input.ToLower() == "f" || input.ToLower() == "finish") break;

    //Разделяем строку по ","
    string[] productInfo = input.Split(',');
    //Проверка на корректный ввод
    if (productInfo.Length != 3)
    {
        Console.WriteLine("Неправильный формат. Введите продукт в формате 'название, объем, стоимость'.");
        continue;
    }

    string productName;
    // Записываем название продукта в productName если оно не пустое
    if (!string.IsNullOrWhiteSpace(productInfo[0])) productName = productInfo[0].Trim();
    else
    {
        Console.WriteLine("Введите имя продукта!");
        continue;
    }

    //Флаг для проверки уже существующего продукта
    bool productExists = false;

    foreach(var product in products)
    {
        //если продукт найден в списке...
        if(product.Name.ToLower() == productName.ToLower())
        {
            productExists = true;   //изменяем статус флага
            //Выводим сообщение и спрашиваем у пользователя...
            Console.Write($"Продукт {productName} уже добавлен. Хотите обновить объем и стоимость продукта? (y/n): ");
            string updateChoice = Console.ReadLine().ToLower();

            //Если ответ да, то обновляем
            if (updateChoice == "y")
            {
                // Преобразовываем значения из строк productInfo[1] и productInfo[2] в числа типа double и проверяем на правильный ввод
                if (!double.TryParse(productInfo[1], out double newVolume) || !double.TryParse(productInfo[2], out double newPrice) || newVolume < 0 || newPrice < 0)
                {
                    Console.WriteLine("Неверные данные для объема или стоимости продукта! (Или отрицательные данные)");
                    continue;
                }
                else
                {
                    // Обновляем объем и стоимость продукта
                    product.Volume = double.Parse(productInfo[1]);
                    product.Price = double.Parse(productInfo[2]);
                    Console.WriteLine("Продукт обновлён!");
                }
            }
            else continue;  //иначе продолжаем ввод нового продукта

        }
    }

    //Если же продукта еще нет в списке, то добавляем его
    if (!productExists) 
    {
        // Преобразовываем значения из строк productInfo[1] и productInfo[2] в числа типа double и проверяем на правильный ввод
        if (!double.TryParse(productInfo[1], out double volume) || !double.TryParse(productInfo[2], out double price) || volume < 0 || price < 0)
        {
            Console.WriteLine("Неверные данные для объема или стоимости продукта! (Или отрицательные данные)");
            continue;
        }

        // Создаём новый объект Product и сразу записываем данные продукта, затем этот объект добавляем в список products
        products.Add(new Product { Name = productName, Volume = volume, Price = price });
    }
}

/*------------------------------------------------Ввод рецепта--------------------------------------------------------------------------*/
Console.WriteLine("****************************************************************************");
//Вводим данные рецепта
Console.Write("Введите название Рецепта: ");
string recipeName = Console.ReadLine(); //Может быть null (то есть вводить по желанию!)

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
            Console.Write("\tНеправильное объём(количество). Введите целое число: ");
        }
        else if (volume == 0 || volume > product.Volume)
        {
            Console.Write("\tНеобходимый объём не может быть равен 0 или больше самого объёма: ");
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
    Console.Write("Неправильное количество порций. Введите целое число: ");
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
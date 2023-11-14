using FoodServingCost;
using System.Text;

//установка кодировки консоли в UTF-8
Console.OutputEncoding = Encoding.UTF8;
Console.InputEncoding = Encoding.UTF8;

//Лист для хранение ингредиентов
List<Ingredient> ingredients = new List<Ingredient>();

/*------------------------------------------------Ввод рецепта--------------------------------------------------------------------------*/
Console.WriteLine("****************************************************************************");
//Вводим название рецепта
Console.Write("Введите название Рецепта: ");
string recipeName = Console.ReadLine(); //Может быть null (то есть вводить по желанию!)

//Вводим количество порций
Console.Write("Введите количество порций блюда: ");
double servings;
while (true)
{
    if (!double.TryParse(Console.ReadLine(), out double serv) || serv <= 0) Console.Write("Неправильное количество порций. Введите целое число: ");
    else
    {
        servings = serv;
        break;
    }
}

/*------------------------------------------------Ввод Продуктов---------------------------------------------------------*/
Console.WriteLine("****************************************************************************");
Console.WriteLine("Введите информацию о продуктах (название, стоимость, объем, необходимый объем в рецепте) \nили 'f (finish)' для завершения ввода:");
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
    if (productInfo.Length != 4)
    {
        Console.WriteLine("Неправильный формат. Введите продукт в формате 'название, стоимость, объем, необходимый объем в рецепте'.");
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
    // Преобразовываем значения из строк productInfo[1] и productInfo[2] в числа типа double и проверяем на правильный ввод
    if (!double.TryParse(productInfo[1], out double price) || !double.TryParse(productInfo[2], out double volume) || volume < 0 || price < 0)
    {
        Console.WriteLine("Неверные данные для стоимости или объема продукта! (Или отрицательные данные)");
        continue;
    }
    if (!double.TryParse(productInfo[3], out double requiredVolume)) 
    { 
        Console.WriteLine("Неправильный необходимый объём(количество). Введите число: ");
        continue;
    }
    if (requiredVolume <= 0 || requiredVolume > volume)
    {
        Console.WriteLine("Необходимый объём не может быть равен 0 или больше самого объёма: ");
        continue;
    }

    //Флаг для проверки уже существующего продукта
    bool productExists = false;

    foreach(var ingredient in ingredients)
    {
        //если продукт найден в списке...
        if(ingredient.Product.Name.ToLower() == productName.ToLower())
        {
            productExists = true;   //изменяем статус флага
            //Выводим сообщение и спрашиваем у пользователя...
            Console.Write($"Продукт {productName} уже добавлен. Хотите обновить объем и стоимость продукта? (y/n): ");
            
            //Если ответ да, то обновляем
            if (Console.ReadLine().ToLower() == "y")
            {
                // Обновляем объем и стоимость продукта
                ingredient.Product.Price = double.Parse(productInfo[1]);
                ingredient.Product.Volume = double.Parse(productInfo[2]);
                ingredient.RequiredVolume = double.Parse(productInfo[3]);
                Console.WriteLine("Продукт обновлён!");
            }
            else continue;  //иначе продолжаем ввод нового продукта

        }
    }

    //Если же продукта еще нет в списке, то добавляем его
    if (!productExists) 
    {
        // Создаём новый объект Ingredient и сразу записываем данные продукта, затем этот объект добавляем в список ingredients
        ingredients.Add(
            new Ingredient 
            { 
                Product = new Product { Name = productName, Volume = volume, Price = price }, 
                RequiredVolume = requiredVolume
            }
        );
    }
}

//Создаём объект и заполняем его данными
Recipe recipe = new Recipe()
{
    Name = recipeName,
    Ingredients = ingredients,
    Servings = servings
};

Console.WriteLine("****************************************************************************");

/*---------------------------------------------------Вывод резултата-----------------------------------------------------------------------*/

//У 'recipe' вызываем метод calculateCostPerServing и записываем его результат в totalCost
double totalCost =  recipe.calculateCostPerServing();
//Выводим стоимость одной порции блюда
Console.WriteLine($"Стоимость одной порции блюда {recipe.Name}: {totalCost} - {Math.Round(totalCost, 2)} рублей");
Console.WriteLine("****************************************************************************");

Console.ReadLine();
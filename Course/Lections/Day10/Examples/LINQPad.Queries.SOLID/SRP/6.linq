<Query Kind="Program" />

#region God object
//Предел нарушения принципа единственности ответственности – God object.
//Этот объект знает и умеет делать все, что только можно. Например, 
//он делает запросы к базе данных, к файловой системе, общается по 
//протоколам в сеть и содержить тонну бизнес-логики. В пример приведу 
//объект, который называется ImageHelper:
#endregion

public static class ImageHelper
{
    public static void Save(Image image)
    {
        // сохранение изображение в файловой системе
    }
 
    public static int DeleteDuplicates()
    {
        // удалить из файловой системы все дублирующиеся изображения и вернуть количество удаленных
    }
 
    public static Image SetImageAsAccountPicture(Image image, Account account)
    {
        // запрос к базе данных для сохранения ссылки на это изображение для пользователя
    }
 
    public static Image Resize(Image image, int height, int width)
    {
        // изменение размеров изображения
    }
 
    public static Image InvertColors(Image image)
    {
        // изменить цвета на изображении
    }
 
    public static byte[] Download(Url imageUrl)
    {
        // загрузка битового массива с изображением с помощью HTTP запроса
    }
 
    // и т.п.
}

//Кажется, что границы ответственности у него вообще нет. 
//Он может сохранять в базу данных, причем знает правила назначения
//изображений пользователям. Может скачивать изображения. Знает,
//как хранятся файлы изображений и может работать с файловой системой.

//Каждая ответственность этого класса ведет к его потенциальному изменению. 
//Получается, что этот класс будет очень часто менять свое поведение, 
//что затруднит его тестирование и тестирование компонентов, которые его используют.
//Такой подход снизит работоспособность системы и повысит стоимость ее сопровождения.

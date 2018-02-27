using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CustomValidationAttribute.Models
{
    public class MustBeTrueAttribute : ValidationAttribute
    {
        // Если метод возвращает true - значение свойства допустимо.
        // При значении false - возникнет ошибка на уровне свойства.
        // Таким же способом можно создавать атрибуты для всей модели. 
        // В случае атрибута для всей модели,
        // значения параметра value метода IsValid будет экземпляром модели, 
        // а не значением свойства, как в данном случае.
        public override bool IsValid(object value)
        {
            // если тип проверяемого значения bool, а значение true - возвращаем true
            return value is bool && (bool)value;
        }
    }
}
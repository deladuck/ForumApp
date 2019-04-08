using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Forum.Models {
    public class ThreadDbInitializer : DropCreateDatabaseIfModelChanges<ForumContext>{

        protected override void Seed(ForumContext context) {
            context.Threads.Add(new Thread(1, "Тестовая тема №1", "Тестовое описание раздела для проверки работоспособности системы. <br> <h1>Проверка HTML кода</h1>", "5362226c-8c12-48b9-a697-d50d568efdb2"));
            context.Threads.Add(new Thread(2, "Тестовая тема №2", "Тестовое описание раздела для проверки работоспособности системы. <br> <h1>Проверка HTML кода</h1>", "5362226c-8c12-48b9-a697-d50d568efdb2"));
            context.Threads.Add(new Thread(3, "Тестовая тема №3", "Тестовое описание раздела для проверки работоспособности системы. <br> <h1>Проверка HTML кода</h1>", "5362226c-8c12-48b9-a697-d50d568efdb2"));

            base.Seed(context);
        }

    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Forum.Models {
    public class ThreadDbInitializer : DropCreateDatabaseIfModelChanges<ForumContext>{

        protected override void Seed(ForumContext context) {
            context.Threads.Add(new Thread(1, "Веб-форум", "Веб-форум — платформа для общения между пользователями интернета на одну тему или на несколько тем (зависит от специализации форума). <br> <p><b>Концепция</b></p> Суть работы форума заключается в создании пользователями (посетителями форума) своих Тем с их последующим обсуждением, путём размещения сообщений внутри этих тем. Отдельно взятая тема, по сути, представляет собой тематическую гостевую книгу. Пользователи могут комментировать заявленную тему, задавать вопросы по ней и получать ответы, а также сами отвечать на вопросы других пользователей форума и давать им советы. Внутри темы также могут устраиваться Опросы (голосования), если это позволяет движок. Вопросы и ответы сохраняются в базе данных форума, и в дальнейшем могут быть полезны как участникам форума, так и любым пользователям сети Интернет, которые могут зайти на форум, зная адрес сайта, или получив его от поисковых систем при поиске информации.", "0"));
            context.Threads.Add(new Thread(2, "Тестовая тема", "Тестовое описание раздела для проверки работоспособности системы. <br> <h1>Полёт нормальный</h1>", "0"));

            base.Seed(context);
        }

    }
}
# Image Processor
### Средства разработки
Язык C#.
### Возможности проекта
* Диалог выбора изображения.
* Фильтр изображений по форматам .jpg, .jpeg, .png, .gif.
* Выбор степени размытия изображения.
* Выбор формы структурирующего элемента для морфологической обработки.
* Выбор размера структурирующего элемента для морфологической обработки.
### Примечания
* Морфологическая обработка включает применение к изображению дилатации, эрозии, замыкания и размыкания в соответствии с выбранным структурирующим элементом.
* Структурирующие элементы представляют собой некоторую маску, которая определяет область изображения, над которой будет произведена операция морфологии.
* Результат операции эрозии представляет собой множество, состоящее из центральных пикселей всех структурирующих элементов, которые целиком помещаются внутри области.
* Результат операции дилатации представляет собой множество, состоящее из центральных пикселей всех структурирующих элементов, у которых хотя бы одна точка лежит внутри области.
* Размыкание сглаживает контуры объекта, обрывает узкие перешейки и ликвидирует выступы небольшой ширины (эрозия + дилатация).
* Замыкание также проявляет тенденцию к сглаживанию участков контуров. В общем случае "заливает" узкие разрывы и длинные углубления малой ширины, а также ликвидирует небольшие отверстия и заполняет промежутки контура (дилатация + эрозия).

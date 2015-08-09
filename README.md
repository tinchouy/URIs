# URIs

http://ole.michelsen.dk/blog/serialize-object-into-a-query-string-with-reflection.html
https://dotnetfiddle.net/3G57RU

Este deber fue mandado por Sebastián el miércoles 5 de Agosto del 2015 y muestra como 
crear un QueryString dinámicamente, con la ayuda del fiddle.

Uso:

Para cualquier objeto (i.e: "object") que no sea una lista o una clase: object.ToQueryString().ToURL("www.somepage.com/index.aspx")

Siendo object el siguiente objeto:
Objeto object = new Objeto() { Tipo = 2, Nombre = "TinchoUY" }

El resultado sería el siguiente: "www.somepage.com/index.aspx?Tipo=2&Nombre=TinchoUY"

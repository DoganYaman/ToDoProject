# Console ToDo Uygulaması

###  Uygulamanın yapısı genel olarak aşağıdaki gibi olmalıdır : 

* Board 3 tane Line dan oluşur.

* Her bir line bir kart listesi tutar

* Kartların büyüklükleri pre-defined olan bir enum'da tutulur.

* Kart sadece takım üyelerinden birine atanabilir.

* Takım üyeleri daha önceden varsayıla olarak tanımlanmış bir listede olmalı. Struct, class ya da bir koleksiyon kullanılabilir.

##### Ana Menü : 

* Kart Ekle
* Kart Güncelle
* Kart Sil
* Kart Taşı
* Board Listeleme

##### Kart İçeriği : 

* Baslik
* Icerik
* Atanan Kisi (Takım üyelerinden biri olmalı)
* Büyüklük (XS, S, M, L, XL)

##### Açıklama : 

* Board TODO - IN PROGRESS - DONE kolonlarından oluşmalı.

* Varsayılan olarak bir board tanımlı olmalı ve 3 tane de kart barındırmalı.(Kartlar herhangi bir line'da yani kolonda olabilir.)

* Kartlar ancak takımdan birine atanabilir. Takımdaki kişiler ise varsayılan olarak tanımlanmalı. Takım üyeleri Dictionary kullanılarak key-value pair şeklinde ya da bir sınıf aracılığıyla tutulabilir. Kartlara atama yapılırken takım üyeleri ID leri ile atanacak. Yani kullanılacak yapının mutlaka bir ID içermesi gerekir.

* Uygulama ilk başladığında kullanıcıya yapmak istediği işlem seçtirilir.


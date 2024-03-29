const products = [
    {
        ratingReviews: '264 отзыва',
        price: {
            oldUan: '4 333 грн',
            newUan: '3 799 грн',
        },
        name: 'Motorola MOTO G4 (XT1622) Black',
    }, {
        ratingReviews: '1355 отзывов',
        price: '4 999 грн',
        name: 'Samsung Galaxy J7 J700H/DS Black + карта памяти 16гб + чехол + защитное стекло!',
    }, {
        ratingReviews: '426 отзывов',
        price: '5 199 грн',
        name: 'Samsung Galaxy J5 (2016) J510H/DS Black + защитное стекло + чехол!',
    }, {
        ratingReviews: '403 отзыва',
        price: '4 349 грн',
        name: 'Xiaomi Redmi Note 4X 3/32GB Black',
    }, {
        ratingReviews: '488 отзывов',
        price: '6 199 грн',
        name: 'Samsung Galaxy J7 (2016) J710F/DS Gold + защитное стекло + чехол!',
    }, {
        ratingReviews: '198 отзывов',
        price: {
            oldUan: '3 495 грн',
            newUan: '2 995 грн',
        },
        name: 'Lenovo K5 (A6020a40) Silver',
    }, {
        ratingReviews: '352 отзыва',
        price: {
            oldUan: '9 799 грн',
            newUan: '7 999 грн',
        },
        name: 'Apple iPhone 5s 16GB Space Gray',
    }, {
        ratingReviews: '59 отзывов',
        price: '6 000 грн',
        name: 'Nokia 5 Dual Sim Tempered Blue',
    }, {
        ratingReviews: '119 отзывов',
        price: '11 999 грн',
        name: 'Samsung Galaxy A5 2017 Duos SM-A520 Black + карта памяти 128гб!',
    }, {
        ratingReviews: '1106 отзывов',
        price: '3 999 грн',
        name: 'Samsung Galaxy J5 J500H/DS Black + чехол + защитное стекло!',
    }, {
        ratingReviews: '380 отзывов',
        price: '2 199 грн',
        name: 'Huawei Y3 II Tiffany (White-Blue) + чехол + защитное стекло!',
    }, {
        ratingReviews: '86 отзывов',
        price: {
            oldUan: '24 999 грн',
            newUan: '22 999 грн',
        },
        name: 'Samsung Galaxy S8 64GB Midnight Black + карта памяти 64гб + оригинальный чехол!',
    }, {
        ratingReviews: '177 отзывов',
        price: '6 499 грн',
        name: 'Huawei P8 Lite 2017 White + УМБ Huawei AP08Q + защитное стекло + чехол!',
    }, {
        ratingReviews: '347 отзывов',
        price: '4 299 грн',
        name: 'Xiaomi Redmi 4X 3/32GB Black (Международная версия)',
    }, {
        ratingReviews: '709 отзывов',
        price: '2 799 грн',
        name: 'Samsung Galaxy J1 2016 SM-J120H Black + защитное стекло + чехол!',
    }, {
        ratingReviews: '527 отзывов',
        price: '3 999 грн',
        name: 'Huawei Y6 Pro Gold + чехол + защитное стекло!',
    }, {
        ratingReviews: '66 отзывов',
        price: '16 499 грн',
        name: 'Apple iPhone 6s 32GB Gold',
    }, {
        ratingReviews: '14 отзывов',
        price: '11 499 грн',
        name: 'Apple iPhone 6 32GB Space Gray',
    }, {
        ratingReviews: '70 отзывов',
        price: {
            oldUan: '7 399 грн',
            newUan: '5 999 грн',
        },
        name: 'Asus ZenFone 2 32GB (ZE551ML) Black',
    }, {
        ratingReviews: '45 отзывов',
        price: '4 299 грн',
        name: 'Nokia 3 Dual Sim Silver White + сертификаты 500 грн!',
    }, {
        ratingReviews: '376 отзывов',
        price: '3 899 грн',
        name: 'Meizu M3 Note 32GB Grey (Международная версия)',
    }, {
        ratingReviews: '111 отзывов',
        price: {
            oldUan: '9 999 грн',
            newUan: '7 999 грн',
        },
        name: 'Sony Xperia X Dual (F5122) White',
    }, {
        ratingReviews: '40 отзывов',
        price: '2 222 грн',
        name: 'Lenovo Vibe C (A2020) Black + УМБ PowerPlant 5200 mAh в подарок!',
    }, {
        ratingReviews: '93 отзыва',
        price: '18 999 грн',
        name: 'Apple iPhone 7 32GB Black',
    }, {
        ratingReviews: '33 отзыва',
        price: '16 999 грн',
        name: 'Huawei P10 4/32GB Black + сертификат 2500грн + чехол Huawei Smart View Cover!',
    }, {
        ratingReviews: '71 отзыв',
        price: {
            oldUan: '2 399 грн',
            newUan: '1 999 грн',
        },
        name: 'LG K5 X220ds Gold',
    }, {
        ratingReviews: '39 отзывов',
        price: '2 995 грн',
        name: 'Lenovo C2 Power (K10a40) Black',
    }, {
        ratingReviews: '156 отзывов',
        price: '2 599 грн',
        name: 'Nous NS 5006 Gold',
    }, {
        ratingReviews: '40 отзывов',
        price: '19 689 грн',
        name: 'LG G6 Mystic White',
    }, {
        ratingReviews: '24 отзыва',
        price: '5 995 грн',
        name: 'Motorola MOTO G5 (XT1676) Grey',
    }, {
        ratingReviews: '7 отзывов',
        price: {
            oldUan: '10 999 грн',
            newUan: '9 999 грн',
        },
        name: 'HTC One X10 Dual Sim Silver',
    }, {
        ratingReviews: '18 отзывов',
        price: {
            oldUan: '5 999 грн',
            newUan: '4 999 грн',
        },
        name: 'Sony Xperia L1 Dual Black',
    }];


const sortedByRating = () => {
  let sorted=Array(products.length);
  for (let index = 0; index < products.length; index++) {
    sorted[index]=products[index];
  }

  sorted.sort(function(a,b){
    let a_rew=Number.parseInt( a.ratingReviews.split(' ')[0]);
    let b_rew=Number.parseInt( b.ratingReviews.split(' ')[0]);
    return b_rew-a_rew;
  });
  return sorted;
};

const sortedByPrice = () => {
    let sorted=Array(products.length);
  for (let index = 0; index < products.length; index++) {
    sorted[index]=products[index];
  }
    sorted.sort(function(a,b){
        let a_price,b_price;
        try {
            a_price=Number.parseInt( a.price.replace(' ','').split(' грн')[0]);
        } catch (error) {
            a_price=Number.parseInt( a.price.newUan.replace(' ','').split(' грн')[0]);
        }
        try {
            b_price=Number.parseInt( b.price.replace(' ','').split(' грн')[0]);
        } catch (error) {
            b_price=Number.parseInt( b.price.newUan.replace(' ','').split(' грн')[0]);
        }
        return b_price-a_price;
        
    });
    return sorted;
  };

module.exports = {sortedByRating, sortedByPrice, products};

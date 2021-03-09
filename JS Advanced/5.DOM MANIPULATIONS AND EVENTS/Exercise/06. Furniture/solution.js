function solve() 
{
  let buttonAdd = document.querySelectorAll('button')[0];
  let buttonBuy = document.querySelectorAll('button')[1];
  let addTextArea = document.querySelectorAll('textarea')[0];
  let boughtTextArea = document.querySelectorAll('textarea')[1];

  let tBody = document.querySelector('tbody');

  buttonAdd.addEventListener('click', addProduct)
  buttonBuy.addEventListener('click', extract)


  function extract()
  {
    let table = document.querySelectorAll('tbody tr');

    let bought = [];
    let totalPrice = 0;
    let allDecFactor = [];

    table.forEach(element => 
    {
      if (element.children[4].children[0].checked)
      {
        bought.push(element.children[1].textContent);
        totalPrice += Number(element.children[2].textContent);
        allDecFactor.push(Number(element.children[3].textContent));
      }
    });

    let averageDecFactor = allDecFactor.reduce((a, b) => a + b, 0) / allDecFactor.length;

    boughtTextArea.value += `Bought furniture: ${bought.join(', ')}\n`;
    boughtTextArea.value += `Total price: ${totalPrice.toFixed(2)}\n`;
    boughtTextArea.value += `Average decoration factor: ${averageDecFactor}\n`;
  }

  function addProduct(e)
  {
    let product = JSON.parse(addTextArea.value)


    product.forEach(element => 
    {
      let newRow = document.createElement('tr');

      AddImage(element, newRow);
      AddName(element, newRow);
      AddPrice(element, newRow);
      AddDecFactor(element, newRow);
      AddMarkBox(newRow);
      tBody.appendChild(newRow);

    });

    function AddMarkBox(newRow)
    {
      let markTD = document.createElement('td');
      let mark = document.createElement('input');
      mark.type = 'checkbox';
      markTD.appendChild(mark);
      newRow.appendChild(markTD);
    }

    function AddDecFactor(element, newRow)
    {
      let decorationFactorTD = document.createElement('td');
      let decorationFactor = document.createElement('p');
      decorationFactor.textContent = element.decFactor;
      decorationFactorTD.appendChild(decorationFactor);
      newRow.appendChild(decorationFactorTD);
    }

    function AddPrice(element, newRow)
    {
      let priceTD = document.createElement('td');
      let price = document.createElement('p');
      price.textContent = element.price;
      priceTD.appendChild(price);
      newRow.appendChild(priceTD);
    }

    function AddName(element, newRow)
    {
      let nameTD = document.createElement('td');
      let name = document.createElement('p');
      name.textContent = element.name;
      nameTD.appendChild(name);
      newRow.appendChild(nameTD);
    }

    function AddImage(element, newRow)
    {
      let imgTD = document.createElement('td');
      let img = document.createElement('img');
      img.src = element.img;
      imgTD.appendChild(img);
      newRow.appendChild(imgTD);
    }
  }
}
function x(input) {
    let list = [];
    for (let el of input) {
        list.push(JSON.parse(el));
    }
    list.forEach(s => console.log(`Name: ${s.name}\nAge: ${s.age}\nDate: ${s.date}`));
}
// x([ '{"name":"Gosho","age":10,"date":"19/06/2005"}',
//     '{"name":"Tosho","age":11,"date":"04/04/2005"}',
//     '{"name":"Maria","age":24,"date":"31/12/1996"}' ]);
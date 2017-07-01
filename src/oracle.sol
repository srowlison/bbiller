pragma solidity ^0.4.9;

// contract oracleTest {
//     bytes32 public rate;

//     function otest() {
//         //use brave new coin oracle 0x25dc90faa727aa29e437e660e8f868c9784d3828, checked sum 0x25Dc90FAa727aa29e437E660e8F868C9784D3828
//         Oracle o = Oracle(0x25Dc90FAa727aa29e437E660e8F868C9784D3828);
//         rate = o.current();
//     }
// }

contract Oracle{
    uint256 public _DayAvgPrice;
    uint256 public _DayHighestPrice;
    uint256 public _DayLowestPrice;
    uint256 public _LastPrice;
    
	function Oracle()
    {
    }

	function update(uint256 dayAvgPrice, uint256 dayHighestPrice, uint256 dayLowestPrice, uint256 lastPrice)
    {
        _current = newCurrent;
    }

	function current() constant returns(bytes32 current)
    {
        return _current;
    }
}
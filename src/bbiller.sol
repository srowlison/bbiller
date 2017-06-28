pragma solidity ^0.4.9;

contract BBiller {

    uint256 public totalSupply;
    address public owner;
    string public symbol = '';
    string public name = 'BBiller';

    uint256 public earlyBirdDate; //Early bird discount applies before this date.
    uint256 public earlyBirdSupply; //

    //uint256 _earlyBirdDate, uint256 _earlyBirdSupply, uint256 _earlyBirdRate
    function BBiller() {
        owner = msg.sender;
        totalSupply = 1000000;

        //Issue coins to contract owner
        balances[msg.sender] = totalSupply;

        //2018/1/1 00:00 GMT
        earlyBirdDate = 1514764800;
        earlyBirdSupply = 500000;
    }

    function transfer(address _to, uint256 _value) returns (bool success) {
        if (_to == 0x0) throw;
        if (balances[msg.sender] >= _value && _value > 0) 
        {
            balances[msg.sender] -= _value;
            balances[_to] += _value;
            Transfer(msg.sender, _to, _value);
            return true;
        }
        else 
        { 
            return false; 
        }
    }

    function balanceOf(address _owner) constant returns (uint256 balance) {
        return balances[_owner];
    }

    function buy() payable {
        //use brave new coin oracle 0x25dc90faa727aa29e437e660e8f868c9784d3828, checked sum 0x25Dc90FAa727aa29e437E660e8F868C9784D3828
        uint256 ethaud = 450;
        uint256 amountToTransfer = msg.value / 1000000000000;

        Oracle o = Oracle(0x25Dc90FAa727aa29e437E660e8F868C9784D3828);
        Buy();
    }

    function otest() returns(bytes32 current) {
        //use brave new coin oracle 0x25dc90faa727aa29e437e660e8f868c9784d3828, checked sum 0x25Dc90FAa727aa29e437E660e8F868C9784D3828
        Oracle o = Oracle(0x25Dc90FAa727aa29e437E660e8F868C9784D3828);
        return o.current();
    }

    //Users can vote on a git hub issue id.  They can vote in favour, no abstane.
    struct GitHubIssue {
        uint256 gitHubId;
        uint256 start;
        uint256 end;
        uint256 inFavourCount;
        uint256 againstCount;
        mapping (address => address) voted;
    }

    //Create a new GitHub issue
    function addIssue(uint256 _gitHubId, uint256 _start, uint256 _end) {
        //Only contract owner can excute
        require(msg.sender == owner);

        //Add to mapping
        issues[_gitHubId] = GitHubIssue ({
            gitHubId: _gitHubId,
            start: _start,
            end: _end,
            inFavourCount: 0,
            againstCount: 0
        });

        //Raise event
        AddIssue(_gitHubId);
    }

    function vote(uint256 _gitHubId, bool inFavour) {
        //voter has tokens and is allowed
        require(balances[msg.sender] > 0);
        
        if (issues[_gitHubId].start > now && issues[_gitHubId].end < now)
        {
            if (inFavour == true)
            {
                issues[_gitHubId].inFavourCount += 1;
            }
            else
            {
                issues[_gitHubId].againstCount += 1;
            }
        }
        else
        {
            throw;
        }
    }

    //Withdraw the eth to a white listed address
    function withdraw(uint256 _amount)
    {
        if (earlyBirdDate < now)
        {
            //in early bird period
            
        }
        else
        {

        }
    }

    mapping (address => uint256) balances;
    mapping  (uint256 => GitHubIssue) issues;

    event Transfer(address indexed _from, address indexed _to, uint256 _value);
    event AddIssue(uint256 _gitHubId);
    event Buy();
}

contract Oracle{
	function Oracle();
	function update(bytes32 newCurrent);
	function current()constant returns(bytes32 current);
}
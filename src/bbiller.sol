pragma solidity ^0.4.11;

contract BBiller {

    uint256 public totalSupply;
    address public owner;
    string public symbol = '';
    string public name = 'BBiller';

    function BBiller() {
        owner = msg.sender;
        totalSupply = 1000000;

        //Issue coins to contract owner
        balances[msg.sender] = totalSupply;
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

    }

    //Users can vote on a git hub issue id.  They can vote in favour, no abstane.
    struct GitHubIssue {
        int gitHubId;
        uint256 start;
        uint256 end;
        uint256 inFavourCount;
        uint256 abstaneCount;
    }

    //Create a new GitHub issue
    function addIssue(_gitHubId, uint256 _start, uint256 _end) {
        //Only contract owner can excute
        require(msg.sender == owner);

        GitHubIssue issue = GitHubIssue ({
            gitHubId: _gitHubId,
            start: _start,
            end: _end,
            inFavourCount: 0,
            abstaneCount: 0
        });

        //Add to mapping
        issues(_gitHubId) = issue;

        //Raise event
        AddIssue();
    }

    mapping (address => uint256) balances;
    mapping (int => GitHubIssue) issues;

    event Transfer(address indexed _from, address indexed _to, uint256 _value);
    event AddIssue();
}
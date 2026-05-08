#include <iostream>

struct Node
{
    int value;

    Node *left;
    Node *right;
    Node *parent;
};

class Tree
{
    Node* root;
public:
    Tree();
    ~Tree();
    void print(Node* node) const;
    Node* search(Node* node, int val) const;
    Node* min(Node* node) const;
    Node* max(Node* node) const;
    Node* next(Node* node) const;
    Node* prev(Node* node) const;
    void insert(Node* node);
    void insert(int* arr, size_t size);
    void insert(int value);
    void del(Node* node = nullptr);
    Node* getRoot() const;

};

int main()
{
    Tree tr;
    const size_t size{9};
    int arr[size]{15, 27, 30, 39, 45, 50, 70, 90, 103};
    tr.insert(arr, size);
    
    tr.print(tr.getRoot());
    std::cout << '\n';

    tr.insert(55);
    tr.print(tr.getRoot());

    return 0;
}

Tree::Tree()
{ root = nullptr; }

Tree::~Tree()
{ del(); }

void Tree::print(Node *node) const
{
    if(node == nullptr) return;
    
    print(node->left);
    std::cout << node->value << ' ';
    print(node->right);
}

Node *Tree::search(Node *node, int val) const
{
    while(node != nullptr && node->value != val)
    {
        if(val < node->value)
            node = node->left;
        else
            node = node->right;
    }
    return node;
}

Node *Tree::min(Node *node) const
{
    if(node != nullptr)
    {
        while(node->left != nullptr)
            node = node->left;
    }
    return node;
}

Node *Tree::max(Node *node) const
{
    if(node != nullptr)
    {
        while(node->right != nullptr)
            node = node->right;
    }
    return node;
}

Node *Tree::next(Node *node) const
{
    Node* y{nullptr};
    if(node != nullptr)
    {
        if(node->right != nullptr)
            return min(node->right);

        y = node->parent;
        while(y != nullptr && node == y->right)
        {
            node = y;
            y = y->parent;
        }
    }
    return y;
}

Node *Tree::prev(Node *node) const
{
        Node* y{nullptr};
    if(node != nullptr)
    {
        if(node->left != nullptr)
            return max(node->left);

        y = node->parent;
        while(y != nullptr && node == y->left)
        {
            node = y;
            y = y->parent;
        }
    }
    return y;
}

void Tree::insert(Node *node)
{
    node->left = nullptr;
    node->right = nullptr;

    Node* y{nullptr};
    Node* n{root};

    while (n != nullptr)
    {
        y = n;
        if(node->value < n->value)
            n = n->left;
        else
            n = n->right;
    }
    
    node->parent = y;
    
    if(y == nullptr)
        root = node;
    else if(node->value < y->value)
        y->left = node;
    else
        y->right = node;
}

void Tree::insert(int *arr, size_t size)
{
    for(size_t i{}; i < size; i++)
    {
        Node* node{new Node{arr[i], nullptr, nullptr, nullptr}};
        insert(node);
    }
}

void Tree::insert(int value)
{
    Node* node{new Node{value, nullptr, nullptr, nullptr}};
    insert(node);
}

void Tree::del(Node *node)
{
    if(node != nullptr)
    {
        Node* n;
        Node* y;

        if(node->left == nullptr || node->right == nullptr)
            y = node;
        else
            next(node);

        if(y->left != nullptr)
            n = y->left;
        else
            n = y->right;

        if(y->parent == nullptr)
            root = n;
        else if(y == y->parent->left)
            y->parent->left = n;
        else 
            y->parent->right = n;

        if(y != node)
            node->value = y->value;
        delete y;
    }
    else
    {
        while(root != nullptr)
            del(root);
    }
}

Node *Tree::getRoot() const
{ return root; }

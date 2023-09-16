using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace LWord
{
    public class Node
    {
        private String element;
        private Node next, prev;
        public Node(String s, Node n, Node p)
        {
            element = s;
            next = n;
            prev = p;
        }
        public String getElement() { return element; }
        public Node getNext() { return next; }
        public Node getPrev() { return prev; }
        public void setElement(String e) { element = e; }
        public void setNext(Node n) { next = n; }
        public void setPrev(Node n) { prev = n; }

        public void insertFirst(Node list, string newElement)
        {
            Node newNode = new Node(newElement, list, null);
            list.setPrev(newNode);
        }

        public void insertLast(Node list, string newElement)
        {
            Node newNode = new Node(newElement, null, null);

            if (list.element == null)
            {
                list = newNode;
                newNode.setPrev(null);
            }
            else
            {
                Node aux = list;
                while(aux.getNext() != null)
                {
                    aux = aux.getNext();
                }

                aux.setNext(newNode);
                newNode.setPrev(aux);
            }
        }

        public void insertOrdenate( string newElement)
        {
            Node newNode = new Node(newElement, null, null);

            // Eh o primeiro elemento da lista
            if (this.getNext() == null && this.getPrev() == null)
            {
                this.setElement(newNode.getElement());
                this.setPrev(newNode.getPrev());
                this.setNext(newNode.getNext());
            }

            else if(string.Compare(newNode.getElement(), this.getElement()) < 0)
            {
                newNode.setNext(this);
                this.setPrev(newNode);

                this.setElement(newNode.getElement());
                this.setPrev(newNode.getPrev());
                this.setNext(newNode.getNext());
            }

            else
            {
                Node aux = this;
                while(aux.getNext() != null && string.Compare(newNode.getElement(), aux.getNext().getElement()) > 0)
                {
                    aux = aux.getNext();
                }

                newNode.setNext(aux.getNext());
                if(aux.getNext() != null)
                {
                    aux.getNext().setPrev(newNode);
                }

                newNode.setPrev(aux);
                aux.setNext(newNode);
            }
        }

        public Node find(string element)
        {
            Node aux, node = new Node(null, null, null);

            aux = this;
            while(aux != null && aux.getElement().ToLower() != element.ToLower())
            {
                aux = aux.getNext();
            }

            if(aux != null && aux.getElement() != null)
            {
                node = aux;
            }

            return node;
        }

        public void print()
        {
            Debug.WriteLine(this.getElement());

            Node node = this.getNext();
            while(node != null)
            {
                Debug.WriteLine(node.getElement());
                node = node.getNext();
            }

            Debug.WriteLine("\n\n");
        }
    }

}

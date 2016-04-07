simple_console
=============

A simple formatter for console output. 
- Adds some "sugar" to make output more understandable
- Formats bits of strings in ASCII-colour mode to be printed on terminals


usage
=====
    
         
    sc = Simple::Console.new(:colour_output => true)
    puts sc.info('hello world') # will print colour message "hello world"
    puts sc.info('Alexey Melezhik', :title =>'Name') # will print colour message "Name: Alexey Melezhik"
    puts sc.error('Bad error') # will print colour message "ERROR: Bad error"
     
    sc = Simple::Console.new(:colour_output => false) # the same things, but in colourless mode
      


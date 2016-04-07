require File.join(File.dirname(__FILE__), '/test_helper.rb')

class SimpleConsoleTest < MiniTest::Unit::TestCase
    def test_colorless_info_with_title
        assert_match "INFO -- : hello world => message",
            Simple::Console.new(:color_output => false).info("message", :title => "hello world")
    end

    def test_colorless_info_without_title
        assert_match "INFO -- : message",
            Simple::Console.new(:color_output => false).info("message")
    end     

    def test_color_info_without_title
        assert_match "message",
            Simple::Console.new(:color_output => true).info("message")
    end     

    def test_color_info_with_title
        assert_match "message",
            Simple::Console.new(:color_output => true).info("message", :title => 'I say')
    end     

end

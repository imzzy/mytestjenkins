package cn.leanpro.model;

import cn.leanpro.annotation.Column;

public class BBSPostModle {

	@Column(name="title")
	private String title;
	@Column(name="content")
	private String content;
	@Column(name="section")
	private String section;
	@Column(name="newtitle")
	private String newtitle;
	@Column(name="newcontent")
	private String newcontent;
	@Column(name="resport")
	private String resport;
	
	public String getResport() {
		return resport;
	}
	public void setResport(String resport) {
		this.resport = resport;
	}
	public String getTitle() {
		return title;
	}
	public void setTitle(String title) {
		this.title = title;
	}
	public String getContent() {
		return content;
	}
	public void setContent(String content) {
		this.content = content;
	}
	public String getSection() {
		return section;
	}
	public void setSection(String section) {
		this.section = section;
	}
	public String getNewtitle() {
		return newtitle;
	}
	public void setNewtitle(String newtitle) {
		this.newtitle = newtitle;
	}
	public String getNewcontent() {
		return newcontent;
	}
	public void setNewcontent(String newcontent) {
		this.newcontent = newcontent;
	}
	
	
}

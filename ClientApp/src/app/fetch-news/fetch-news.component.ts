import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-news',
  templateUrl: './fetch-news.component.html'
})
export class FetchNewsComponent {
  public newsItems: NewsListItem[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<NewsListItem[]>(baseUrl + 'api/news').subscribe(result => {
      this.newsItems = result;
    }, error => console.error(error));
  }
}

interface NewsListItem {
  id: number;
  by: string;
  type: string;
  url: string;
}

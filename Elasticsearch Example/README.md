# Elasticsearch /🔎✨

## I. Các truy vấn cơ bản

### 1. Kiểm tra các **INDEX**

⚙ **Kibana:**

<aside>
💡 GET /_cat/indices?v

</aside>

🔗 **Shell:**

```bash
curl -XGET "http://localhost:9200/_cat/indices?v
```

### 2. Tạo mới **INDEX**

⚙ **Kibana:**

<aside>
💡 PUT /[tên index]?pretty

</aside>

🔗 **Shell:**

```bash
curl -XPUT "http://localhost:9200/[tên index]?pretty
```

### 3. Xóa **INDEX**

⚙ **Kibana:**

<aside>
💡 DEL /[tên index]?pretty

</aside>

🔗 **Shell:**

```bash
curl -XDELETE "http://localhost:9200/[tên index]?pretty
```

### 4. Tạo, sửa DOCUMENT cho INDEX

⚙ **Kibana:**

<aside>
💡 PUT /[tên index]/_doc/[id]
{
     “key1”: “value 1”,
      “key1”: “value 2”
}

</aside>

🔗 **Shell:**

```bash
curl -XPUT "http://localhost:9200/[tên index]/_doc/[id]
{
	"key1": "value 1",
	"key2": "value 2"
}
```

### 5. Xem DOCUMENT theo [id] của INDEX

⚙ **Kibana:**

<aside>
💡 GET /[tên index]/_doc/[id]?pretty

</aside>

🔗 **Shell:**

```bash
curl -XGET "http://localhost:9200/[tên index]/_doc/[id]?pretty
```

### 6. Xóa DOCUMENT theo [id] của INDEX

⚙ **Kibana:**

<aside>
💡 DELETE /[tên index]/_doc/[id]

</aside>

🔗 **Shell:**

```bash
curl -XDELETE "http://localhost:9200/[tên index]/_doc/[id]
```

### 7. Tạo DOCUMENT hàng loạt

⚙ **Kibana:**

<aside>
💡 POST /_bulk
{
     {”index”: {”_index”: “[tên index]”, “_id”: “[id]”}}
     {”key1”: “value 1”, “key2”: “value 2”}
     {”index”: {”_index”: “[tên index]”, “_id”: “[id]”}}
     {”key1”: “value 1”, “key2”: “value 2”}
}

</aside>

✨**Hoặc**: tạo file **data.json**

```json
{"index": {"_index": "[tên index]", "_id": "[id]"}}
{"key1": "value 1", "key2": "value 2"}
{"index": {"_index": "[tên index]", "_id": "[id]"}}
{"key1": "value 1", "key2": "value 2"}
{"index": {"_index": "[tên index]", "_id": "[id]"}}
{"key1": "value 1", "key2": "value 2"}
{"index": {"_index": "[tên index]", "_id": "[id]"}}
{"key1": "value 1", "key2": "value 2"}
```

🔗 **Shell:**

```bash
curl -s -H "Content-Type: application/x-ndjson" -XPOST http://localhost:9200/_bulk/ --data-binary "@**data.json**";
```

## II. Các truy vấn tìm kiếm

### 1. Tìm kiếm theo id

⚙ **Kibana:**

<aside>
💡 GET /[tên index]/_doc/[id]?pretty

</aside>

🔗 **Shell:**

```bash
curl -XGET "http://localhost:9200/[tên index]/_doc/[id]?pretty
```

### 2. Tìm kiếm tất cả (match_all)

⚙ **Kibana:**

<aside>
💡 GET /[tên index]/_search
{
“query”: {”match_all”: {}},
     “sort”: [
     {
         “key”: {
             “order”: “desc hoặc asc”
           }
     }
     ]
     “size” : [số lượng],
     “from”: [số thứ tự bắt đầu]
}

</aside>

🔗 **Shell:**

```bash
curl -XGET "http://localhost:9200/[tên index]/_search?pretty" -H 'Content-Type: application/json' -d
{
	"query": {"match_all": {}},
	"sort": [
		{
			"key": {
				"order" : "desc hoặc asc"
			}
		}
	]
	"size": [số lượng],
	"from": [số thứ tự bắt đầu]
}
```

### 3. Tìm kiếm tất cả (match_all) hiển thị các field đã chỉ định

⚙ **Kibana:**

<aside>
💡 GET /[tên index]/_search {
    “query”: {”match_all”: {}},
    “_source”: [”key1”, “key2”]
}

</aside>

🔗 **Shell:**

```bash
curl -XGET "http://localhost:9200/[tên index]/_search?pretty" -H 'Content-Type: application/json' -d
{
	"query": {"match_all": {}},
	"_source": ["key1", "key2"]
}
```

### 4. Tìm kiếm giá trị phù hợp (match)

⚙ **Kibana:**

<aside>
💡 GET /[tên index]/_search {
    “query”: {”match”: {
          “key”: “[giá trị tìm kiếm]” 
     }}
}

</aside>

🔗 **Shell:**

```bash
curl -XGET "http://localhost:9200/[tên index]/_search?pretty" -H 'Content-Type: application/json' -d
{
	"query": {"match": {
		"key": "[giá trị tìm kiếm]"
	}}
}
```

✨**Note**: Elasticsearch sẽ tìm document có **“_score”** cao hơn (phù hợp hơn) sẽ được sắp xếp lên trước

### 5. Tìm kiếm theo điều kiện logic → tất cả trả về *true* (must) [phép toán AND]

⚙ **Kibana:**

<aside>
💡 GET /[tên index]/_search {
    “query”: {
         “bool”: {
             “must”: [
                  {“match”: {
                 “key1”: “[giá trị tìm kiếm]”
              }},
                 {“match”: {
                 “key2”: “[giá trị tìm kiếm 2]”
                }}
              ]
          }
     }
}

</aside>

🔗 **Shell:**

```bash
curl -XGET "http://localhost:9200/[tên index]/_search?pretty" -H 'Content-Type: application/json' -d
{
	"query": {
		"bool": {
			"must": [
				{"match": {
					"key1": "[giá trị tìm kiếm]"
				}},
				{"match": {
					"key2": "[giá trị tìm kiếm 2]"
				}}
			]
		}
	}
}
```

### 6. Tìm kiếm theo điều kiện logic → 1 trong số các điều kiện *true* (should) [phép toán OR]

⚙ **Kibana:**

<aside>
💡 GET /[tên index]/_search {
    “query”: {
         “bool”: {
             “should”: [
                  {“match”: {
                 “key1”: “[giá trị tìm kiếm]”
              }},
                 {“match”: {
                 “key1”: “[giá trị tìm kiếm 2]”
                }}
              ]
          }
     }
}

</aside>

🔗 **Shell:**

```bash
curl -XGET "http://localhost:9200/[tên index]/_search?pretty" -H 'Content-Type: application/json' -d
{
	"query": {
		"bool": {
			"should": [
				{"match": {
					"key1": "[giá trị tìm kiếm]"
				}},
				{"match": {
					"key1": "[giá trị tìm kiếm 2]"
				}}
			]
		}
	}
}
```

### 7. Tìm kiếm theo điều kiện logic → điều kiện phủ định (must_not)

⚙ **Kibana:**

<aside>
💡 GET /[tên index]/_search {
    “query”: {
         “bool”: {
             “must_not”: [
                  {“match”: {
                 “key1”: “[giá trị tìm kiếm]”
              }},
                 {“match”: {
                 “key2”: “[giá trị tìm kiếm 2]”
                }}
              ]
          }
     }
}

</aside>

🔗 **Shell:**

```bash
curl -XGET "http://localhost:9200/[tên index]/_search?pretty" -H 'Content-Type: application/json' -d
{
	"query": {
		"bool": {
			"must_not": [
				{"match": {
					"key1": "[giá trị tìm kiếm]"
				}},
				{"match": {
					"key2": "[giá trị tìm kiếm 2]"
				}}
			]
		}
	}
}
```

### 8. Tìm kiếm theo điều kiện logic → kết hợp các điều kiện

⚙ **Kibana:**

<aside>
💡 GET /[tên index]/_search {
    “query”: {
         “bool”: {
             “must”: [
                  {“match”: {
                 “key1”: “[giá trị tìm kiếm]”
              }}
              ],
               “must_not”: [
                  {“match”: {
                 “key2”: “[giá trị tìm kiếm]”
              }}
              ],   
          }
     }
}

</aside>

🔗 **Shell:**

```bash
curl -XGET "http://localhost:9200/[tên index]/_search?pretty" -H 'Content-Type: application/json' -d
{
	"query": {
		"bool": {
			"must": [
				{"match": {
					"key1": "[giá trị tìm kiếm]"
				}}
			],
			"must_not": [
				{"match": {
					"key2": "[giá trị tìm kiếm 2]"
				}}
			],
		}
	}
}
```
